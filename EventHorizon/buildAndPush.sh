rm -r bin/release
dotnet publish --runtime linux-arm64 -c Release --no-self-contained
ssh pi@raspberrypi2 "rm -r /home/pi/prod"
scp -r bin/release/net7.0/linux-arm64/publish  pi@raspberrypi2:/home/pi/prod

