# Todo

A minimal project showcasing usage of Docker and Docker Compose tool for local
service development.

This document is a live document evolving through Docker introduction sessions.

## Next Steps

+ Fix entrypoint issue in Dockerfile
  * Solve it for the current project
  * Provide a more generic solution, a more portable Dockerfile
+ Environment variable handling
  * separate configuration for containerized environment
+ Volume handling
+ Dependencies between services
  * What is it good for and what is it not

## Previously on Docker introduction

### First session

+ Tech requirements
  * [Docker for desktop][docker-desktop] (or any other Docker installation)
  * [Todo project repository][todo-project]
  * [Dotnet Core][dotnet-core-install] (Optional, for the local setup tryout)
+ Minimal intro to Dotnet Core MVC app project
  * `dotnet run` - build and run (see `--help` for details)
  * `dotnet publish` - build and package (see `--help` for details)
  * appsetings.json and appsettings.<environment>.json - configuration files
  with connection strings
+ Running a PostgreSQL instance in docker
  * PostgreSQL docker image (and documentation) in [library][pg-docker]
  * Injecting environment variable
  * Expose PostgreSQL server to localhost on 5432
+ Running Todo app connecting to PostgreSQL
  * Adjust connection string
  * `dotnet run --project Todo.csproj`
+ Create Dockerfile
  * [Dockerfile reference][dockerfile]
  * Multistage build, with build-env stage and final stage
  * Creating .dockerignore to exclude local bin and obj folders
  * Build image with `docker build -t 'todo:0.1' .`
+ Creating docker-compose.yaml for project
  * [docker-compose reference][docker-compose-ref]
  * webapp service
    - build context is the current project folder
    - bind localhost:9090 to port 80 of the container
  * db service
    - specify image 'postgre'
    - specify db password as environment variable
+ Start up project
  * `docker-compose up`
  * `docker-compose build` needed on code change to rebuild webapp image
  * webapp container fails on start logging application error

## Questions and Answers

- How much my application coupled to docker? Can I 100% decouple it from docker? I mean later on I may want to use a different container.
  + Docker-Compose what we're using here for project-environment setup is
  coupled with Docker, directly using it's API.
  + The webapp itslef is not coupled to Docker. The Docker image being built
  is an OCI standard container image, which basically a filesystem image with
  some meta labels telling how the author intended their image to run.
  + Docker container runtime is a OCI standard container runtime. Does not
  really differs from jails (BSD) or chroot (linux) which runs a process
  defining what resources it can access and how, providing a virtual environment
  (process level virtualization).
  + Alternatively, OCI standard container images can be built with e.g.:
  [Jib][jib] (Java specific), OCI standard container runtimes: [rkt][rkt] and
  [runc][runc]

[docker-desktop]: https://www.docker.com/products/docker-desktop
[todo-project]: https://github.com/rockkid777/Todo
[dotnet-core-install]: https://dotnet.microsoft.com
[pg-docker]: https://hub.docker.com/_/postgres
[dockerfile]: https://docs.docker.com/engine/reference/builder/
[docker-compose-ref]: https://docs.docker.com/compose/compose-file/
[jib]: https://github.com/GoogleContainerTools/jib
[rkt]: https://coreos.com/rkt/
[runc]: https://github.com/opencontainers/runc
