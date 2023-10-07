#! /bin/bash

# Escape the current directory for use in the sed command
escaped_directory="$(echo "$(pwd)" | sed 's|/|\\\\\\\\|g')"

# Replace the string in the file
sed -i "s|absolute/path/to/program.cs|$escaped_directory\\\\\\\\InterceptorsInCSharp\\\\\\\\Program.cs|g" InterceptorsInCSharp/GeneratedCode.cs

# Print the modified file content
cat InterceptorsInCSharp/GeneratedCode.cs