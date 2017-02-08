Import-Module "$PSScriptRoot\.build\APPBUILD-Shared.psm1"

# Please use semver.org for versioning:
# 1.MAJOR version when you make incompatible API changes,
# 2.MINOR version when you add functionality in a backwards-compatible manner, and
# 3.PATCH version when you make backwards-compatible bug fixes.

# This script appends additional labels to the version number depending on the branch pushed:
# * master builds: 0.0.0-preview<buildNo> (Octopus release, deployed to INT)
# * release/v<maj>.<min>.x & hotfix/v<maj>.<min>.<patch> builds: <maj>.<min>.<patch> (Octopus release, promoted through QA->UAT->LIVE)
# * release/v<maj>.<min>.x/<patch> builds: <maj>.<min>.<patch>-bugfix<buildNo> (build only, for PR requests into release/v<maj>.<min>.x branches
# * feature/* builds: 0.0.0-ci<buildNo> (build only, no release)

# Increment the MAJOR and / or MINOR numbers when a release/* branch is created.

# Name your release branches release/v<maj>.<min>.x (where <maj> and <min> match this file. A release should not span multiple MAJOR or MINOR versions - only the patch number should increment during a release
# Name your hotfix branches hotfix/v<maj>.<min>.<patch> (where MAJOR and MINOR are equal to the tag being checked out, and PATCH is the LIVE version + 1)

$MajorVersion=1
$MinorVersion=0
$PatchVersion=0

#################################
# Do not modify below this line

Update-BuildNumber $MajorVersion $MinorVersion $PatchVersion