# Trivial JS Example

## Build the container image

	$ docker build -t kubia .

> :warning: Do not forget the DOT in the command above

## Running the container image

	$ docker run --name kubia-container -p 8080:8008 -d kubia

Explanation:
* `-d`: detached from console, running in background
* `--name kubia-container kubia`: a new container named as `kubia-container` from `kubia image`
* `-p 8080:8080`: Port 8080 of the local machine will be mapped to port 8080 inside the container. Thus, we can access the app through http://localhost:8080

### Access the app

	$ curl localhost:8080
	
### List running container
	
	$ docker ps

I personally also use the command `ps -aux|grep docker` to checkt the processes


### Getting additional information about a container

	$ docker inspect kubia-container
	
The output is in JSON format.
	
## Exploring the inside of a running container

### Running a shell insides an existing container

	$ docker exec -it kubia-container bash
	
Explanation:
* `-i`, which makes sure STDIN is kept open. You need this to entering command into the shell
* `-t`, which allocates a pseudo terminal (TTY)


## Exploring container from within

### List processes from inside a container

	$ ps aux

In the host machine, if we use `ps aux|grep app.js`, we can also find a running process.
Thus, the process running in the container is running on the host OS.

### The container's filesystem is also isolated

Use the `ls` command, we can easily see an isolated filesystem in the container.

## Stopping and removing the container

### To stop the app

	$ docker stop kubia-container
	
This command will
1. Stop the main process running in the container.
1. Consequently, the container is stopped.

:warning: be aware that 
* The container still exists, you may use the command `docker ps -a` to see it 
	* `-a` option prints all container, including running and stopped containers

## To remove the container

	$ docker rm kubia-container

A removed container cannot be started again.

## Pushing the image to an image registry

For the sake of the simplicity, you won't set up a private image registry. 
Instead we will push the image to [Docker Hub](http://hub.docker.com).

Before that, we need to re-tag the docker. 

### Tagging the image under an addtional tag

	$ docker tag kubia alex031029/kubia
	
Here `alex031029` is my ID.

A container image can have multiple tags. 
This commandline does not rename the tag. 
Instead, it only add a tag for the same image.

### Pushing the image to Docker Hub

	$ docker push alex031029/kubia
