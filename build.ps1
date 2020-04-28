[CmdletBinding(PositionalBinding = $false, DefaultParameterSetName='Groups')]
param (
    # Build lifecycle options
    [switch]$Restore,
    [switch]$NoRestore, # Suppress restore
    [switch]$NoBuild, # Suppress compiling
    [switch]$Pack, # Produce packages
    [switch]$Test, # Run tests

    [Alias('c')]
    [ValidateSet('Debug', 'Release')]
    $Configuration,

    [Parameter(ValueFromRemainingArguments = $true)]
    [string[]]$MSBuildArguments
)

$RunBuild = if ($NoBuild) { $false } else { $true }

# Run restore by default unless -NoRestore is set.
# -NoBuild implies -NoRestore, unless -Restore is explicitly set
$RunRestore = if ($NoRestore) { $false }
    elseif ($Restore) { $true }
    elseif ($NoBuild) { $false }
    else { $true }

if (-not $Configuration) {
    $Configuration = 'Debug'
}
$MSBuildArguments += "/p:Configuration=$Configuration"

if ($RunRestore) {
    dotnet restore ./src/Noobeex.CodeContract.sln
}

$NoRestoreArg = if ($RunRestore) { '--no-restore' } else { '' }

if ($RunBuild) {
    dotnet build --nologo $NoRestoreArg ./src/Noobeex.CodeContract/Noobeex.CodeContract.csproj $MSBuildArguments
}

if ($Test) {
    dotnet test --nologo $NoRestoreArg ./src/Noobeex.CodeContract.sln $MSBuildArguments
}

if ($Pack) {
    dotnet pack --no-build --nologo $NoRestoreArg ./src/Noobeex.CodeContract/Noobeex.CodeContract.csproj $MSBuildArguments
}