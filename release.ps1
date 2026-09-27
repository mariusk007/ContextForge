# Tags the current commit and pushes the tag; GitHub Actions builds and publishes the release.
# Usage: ./release.ps1 0.2.0
param(
    [Parameter(Mandatory)]
    [string]$Version
)

$ErrorActionPreference = 'Stop'
$tag = "v$($Version.TrimStart('v'))"

if (git status --porcelain) {
    throw "Working tree has uncommitted changes. Commit or stash them first."
}

if (git tag --list $tag) {
    throw "Tag $tag already exists."
}

git push origin HEAD
git tag -a $tag -m "Release $tag"
git push origin $tag

Write-Host "Pushed $tag. Watch the build: https://github.com/mariusk007/ContextForge/actions"
