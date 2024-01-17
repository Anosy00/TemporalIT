#!/bin/sh
echo -ne '\033c\033]0;TemporalIT\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/TemporalIT_Windows_Executable.exe.x86_64" "$@"
