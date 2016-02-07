FROM mono:3.10-onbuild
ADD . /akka-app

EXPOSE 8888
EXPOSE 8889
EXPOSE 8899

CMD [ "mono",  "/akka-app/bin/Debug/akka-nancy.exe" ]


