# ASP.NET 5 Docker boilerplate

This project content is based on couple different bits stacked together and tested to be runnable with current ASP.NET 5 releases.

* https://github.com/aspnet/aspnet-docker
* https://github.com/aspnet/Home/blob/dev/samples/latest/HelloWeb/Dockerfile
* https://raw.githubusercontent.com/aspnet/Home/dev/samples/latest/HelloWeb/Dockerfile
* https://github.com/OmniSharp/generator-aspnet/blob/master/templates/Dockerfile.txt
* https://docs.docker.com/reference/builder/#dockerfile-examples

![image](https://cloud.githubusercontent.com/assets/14539/10206287/6320a238-67c6-11e5-8e11-820a3d039a1c.png)

The `Dockerfile` contains fix for Ubuntu 14.04 missing SQLite => 3.7.15 version required by EntityFramework.

## Building and running example with Docker

```
cd AspNetDockerBoilerplate
```

```
docker build -t myapp .
Sending build context to Docker daemon 6.144 kB
Step 0 : FROM microsoft/aspnet:1.0.0-rc1-final
 ---> f42123970b06
Step 1 : RUN printf "deb http://ftp.us.debian.org/debian jessie main\n" >> /etc/apt/sources.list
 ---> Using cache
 ---> 3fb1bd956544
Step 2 : RUN apt-get -qq update && apt-get install -qqy sqlite3 libsqlite3-dev
 ---> Using cache
 ---> a744d237f898
Step 3 : COPY . /app
 ---> 3d0508f71087
Removing intermediate container fec261803cd0
Step 4 : WORKDIR /app
 ---> Running in 746ad8a3b4fb
 ---> 27413244d19c
Removing intermediate container 746ad8a3b4fb
Step 5 : RUN dnu restore
 ---> Running in ad29c3146158
Microsoft .NET Development Utility Mono-x64-1.0.0-rc1-16202
...
Writing lock file /app/project.lock.json
Restore complete, 173198ms elapsed

Feeds used:
    https://api.nuget.org/v3-flatcontainer/

Installed:
    115 package(s) to /root/.dnx/packages
 ---> 6ee70a69f6cc
Removing intermediate container ad29c3146158
Step 6 : EXPOSE 5000/tcp
 ---> Running in 7dc30685735f
 ---> 30ee0c4abf87
Removing intermediate container 7dc30685735f
Step 7 : ENTRYPOINT dnx -p project.json web
 ---> Running in cbc275755686
 ---> 2bfe93805020
Removing intermediate container cbc275755686
Successfully built 2bfe93805020
```

```
docker run -t -d -p 8080:5000 myapp
555a6e973483cc956b0f84f915482c60125655e1b8abbf22f39cabf8a31158de
```

The `.dockerignore` file exludes some assets from being copied and used during Docker image build. Here is what is listed from container's console:
```
# ls -a
.  ..  Startup.cs  hosting.ini	project.json  project.lock.json
```
The `project.lock.json` is a file created within container - the exclusion rules prevent your host machine `project.lock.json` from being moved to container.

## Author
@peterblazejewicz
