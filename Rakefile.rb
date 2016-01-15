#encoding: utf-8
require "./rake-tasks/init"

#-----------------------------------SETTINGS-----------------------------------

$binaries_baselocation = "bin"
$webproject_baselocation = "source"
$installer_location = "#{$binaries_baselocation}/installer"
$nunittesting_location = "#{$binaries_baselocation}/nunittesting"

#--------------------------------build settings--------------------------------

$build_configuration = "debug"

def msbuild_settings
    {
        :targets => [:clean, :rebuild],
        :properties => {
            :configuration => $build_configuration,
            :targetProfile => "Local",
            :visualStudioVersion => 14.0
        },
        :verbosity => :minimal,
        :other_switches => {
            :toolsVersion => 14.0,
            :maxcpucount => true
        }
    }
end

#------------------------------dependency settings-----------------------------
#-------------------------------project settings-------------------------------

$solution = "source/LendingLibrary.sln"

#______________________________________________________________________________
#-------------------------------------TASKS------------------------------------

desc "Builds LendingLibrary and runs tests"
task :default => [:build_test]

desc "Builds and tests without coverage"
task :build_test => [:build_only, :test, :test_web, :check_js]

desc "Builds and tests with coverage"
task :build_coverage => [:build_only, :test_all_with_coverage]

desc "Only builds"
task :build_only => [:clean, :update_packages, :msbuild, :copy_to_bin]

desc "Builds solution with Sonar analysis"
task :build_with_sonar => [:build_coverage, :sonar]

#---------------------------------Update stuff---------------------------------

desc "Updates packages with Nuget"
updatenugetpackages :update_packages do |nuget|
    puts cyan("Updating Nuget packages")
    nuget.solution = $solution
end

#-------------------------------Prepare For Build------------------------------

desc "Cleans the bin folder and all project bin folders"
task :clean do
    puts cyan("Cleaning all bin and test folders")
    FileUtils.rm_rf $binaries_baselocation
    clean_build_output_directories
    clean_coverage_files
end

def clean_build_output_directories
    bin_dirs = Dir.glob("source/**/bin").select {|f| (File.directory? f) && !(f.match(/\/node_modules\//) || f.match(/\/packages\//) || f.match(/\/obj\//))}
    for project_output in bin_dirs
        FileUtils.rm_rf project_output
    end
end

def clean_coverage_files
    FileUtils.rm_rf("buildreports/coverage")
end

task :discover_test_projects do
    $test_projects = []
    if $build_configuration != "release"
        all_dirs = Dir.glob("**/*").select {|f| File.directory? f}
        $test_projects = all_dirs.select {|t| (t.match(/[.]Tests\z/) || t.match(/[.]Specs\z/)) && Dir.exists?(File.join(t, "bin", $build_configuration))}
    end
    $test_dlls = $test_projects.collect {|s| s.split("/").last}
end

#--------------------------------Build Solution--------------------------------

desc "Builds the solution"
msbuild :msbuild do |msb|
    puts green("Build configuration: #{$build_configuration}")
    puts cyan("Building #{$solution} with msbuild")
    msb.update_attributes msbuild_settings
    msb.solution = $solution
end

#----------------------------------Copy Tasks----------------------------------

task :copy_to_bin => [:discover_test_projects] do
    if !$test_projects.empty?
        puts cyan("Copying built files to the bin folder for testing")
        FileSystem.EnsurePath($nunittesting_location)
        copy_release_files_to $nunittesting_location
        copy_nunittesting_files_to $nunittesting_location
    end
end

def copy_release_files_to location
    bin_root = "source/LendingLibrary/bin/#{$build_configuration}"
    FileSystem.CopyWithFolders Dir.glob("#{bin_root}/*"), location, bin_root
end

def copy_nunittesting_files_to location
    for project in $test_projects
        copy_test_project_output_to project, location
    end
end

def copy_test_project_output_to(project, location)
    if Dir.exists?(File.join(project, "bin", $build_configuration))
        FileUtils.cp_r File.join(project, "bin", $build_configuration, "/."), location
    else
        FileUtils.cp_r File.join(project, "bin", "/."), location
    end
end

#---------------------------------Run Web Tests--------------------------------

npm :update_node_packages do |npm|
    npm.base = $webproject_baselocation
end

desc "Launch Karma continuous web test runner"
karma :karma => [:update_node_packages] do |karma|
    puts cyan("Launching Karma continuous web test runner (Ctrl+C to stop)")
    karma.base = $webproject_baselocation
end

desc "Run web tests once"
karma :test_web => [:update_node_packages] do |karma|
    puts cyan("Running web tests with Karma")
    karma.base = $webproject_baselocation
    karma.singlerun = true
end

desc "Run web tests once with coverage"
karma :test_web_with_coverage => [:test_web] do |karma|
    puts cyan("Running web coverage with Karma")
    karma.base = $webproject_baselocation
    karma.coverage = true
end

#-----------------------------------Run Tests----------------------------------

desc "Runs the tests"
nunit :test => [:discover_test_projects] do |nunit|
    puts cyan("Running tests")
    nunit.assemblies testassemblies
end

desc "Runs the tests with dotCover"
dotcover :test_with_coverage => [:discover_test_projects] do |dc|
    puts cyan("Running tests with dotCover")
    dc.assemblies = testassemblies
    dc.filters = "+:module=*;class=*;function=*;-:*.Tests"
end

def testassemblies
    $test_dlls.map {|a| File.join($nunittesting_location, a + ".dll")}
end

#----------------------------All Tests With Coverage---------------------------

task :test_all_with_coverage => [:test_with_coverage, :test_web_with_coverage, :check_js]

#----------------------------------Build Stats---------------------------------

jslint :jslint_no_output do |lint|
    puts cyan("Running JSLint")
    lint.base = $webproject_baselocation
    lint.source = []
end

desc "JSLint with results listed"
jslintoutput :jslint => [:jslint_no_output] do |lint|
    lint.base = $webproject_baselocation
end

desc "Checkstyle"
jslint :checkstyle do |lint|
    puts cyan("Running Checkstyle")
    lint.checkstyle = true
    lint.base = $webproject_baselocation
    lint.source = []
end

desc "Plato"
plato :plato do |plato|
    puts cyan("Running Plato")
    plato.base = $webproject_baselocation
    plato.source = ""
end

desc "JSLint, Checkstyle and Plato"
task :check_js => [:jslint_no_output, :checkstyle, :plato] do
end
