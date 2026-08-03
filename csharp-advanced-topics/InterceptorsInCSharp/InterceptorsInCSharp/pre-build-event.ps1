$curPath = Get-Location
$progCsPath = Join-Path -Path $curPath -ChildPath "Program.cs"
(Get-Content GeneratedCode.cs)
    | ForEach-Object { $_.Replace('"absolute/path/to/program.cs"', "@""${progCsPath}""")}
    | Set-Content GeneratedCode.cs