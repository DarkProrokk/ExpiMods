$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path

# Источник: на 3 уровня ниже (укажи имя папки вместо SourceFolder)
$source = Join-Path $scriptDir "..\TestExpiMod\bin\Debug\net472\TestExpiMod.dll"

# Папка назначения: на 1 уровень выше + plugin
$dest = Join-Path $scriptDir "..\Plugin"

# Создать папку назначения, если её нет
if (!(Test-Path $dest)) {
    New-Item -ItemType Directory -Path $dest | Out-Null
}

# Перенос
Move-Item -Path $source -Destination $dest -Force