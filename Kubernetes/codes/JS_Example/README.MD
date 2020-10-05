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

