#!/bin/sh
echo -ne '\033c\033]0;TemporalIT\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/TemporalIT_Linux_Executable.x86_64" "$@"
