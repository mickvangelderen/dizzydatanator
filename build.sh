#!/usr/bin/env bash

rm -r Build

/opt/Unity/Editor/Unity -quit -batchmode -buildLinux64Player Build/Linux64/DizzyDatanator
tar -zcvf Build/Linux64.tar.gz Build/Linux64

/opt/Unity/Editor/Unity -quit -batchmode -buildOSX64Player Build/OSX64/DizzyDatanator
tar -zcvf Build/OSX64.tar.gz Build/OSX64

/opt/Unity/Editor/Unity -quit -batchmode -buildWindows64Player Build/Windows64/DizzyDatanator
zip -r Build/Windows64.zip Build/Windows64

