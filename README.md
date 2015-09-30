# ASP.NET 5 Docker boilerplate

This project content is based on couple different bits stacked together and tested to be runnable with current ASP.NET 5 releases.

* https://github.com/aspnet/aspnet-docker
* https://github.com/aspnet/Home/blob/dev/samples/latest/HelloWeb/Dockerfile
* https://raw.githubusercontent.com/aspnet/Home/dev/samples/latest/HelloWeb/Dockerfile
* https://github.com/OmniSharp/generator-aspnet/blob/master/templates/Dockerfile.txt
* https://docs.docker.com/reference/builder/#dockerfile-examples

![image](https://cloud.githubusercontent.com/assets/14539/10206287/6320a238-67c6-11e5-8e11-820a3d039a1c.png)

## Building and running example with Docker

```
cd AspNetDockerBoilerplate
```

```
docker build -t docker-bp .
Sending build context to Docker daemon 195.6 kB
Step 0 : FROM ubuntu:14.04
14.04: Pulling from library/ubuntu

d3a1f33e8a5a: Downloading [======>                                            ] 8.093 MB/65.79 MB
c22013c84729: Download complete
d74508fb6632: Download complete
91e54dfb1179: Download complete
...
tep 15 : ENTRYPOINT dnx -p project.json kestrel
 ---> Running in 2b67f1d140d0
 ---> 19b1802b6909
Removing intermediate container 2b67f1d140d0
Successfully built 19b1802b6909
```

```
docker run -p 5000:5000 -d docker-bp
ea7ba1b128312ec5f5ce853d3642f3faee08191ff4b0694ca729c4e1ec7567bc
```

The `.dockerignore` file exludes some assets from being copied and used during Docker image build. Here is what is listed from container's console:
```
# ls -a
.  ..  Startup.cs  hosting.ini	project.json  project.lock.json  wwwroot
```
The `project.lock.json` is a file created within container - the exclusion rules prevent your host machine `project.lock.json` from being moved to container.

## Author
@peterblazejewicz
