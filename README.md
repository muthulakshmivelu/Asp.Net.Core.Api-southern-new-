Southern Manpower Consultancy New Project

API : 

Docker Commands : 

1. docker container ls (List all running containers)

2. docker stop <container_id> (stop running container)

3. docker build -f Asp.Net.Core.Api/Dockerfile -t southern:southernapi .
(Asp.Net.Core.Api/Dockerfile - path for docker file 
southern:southernapi - docker image name)

4. docker run -d -p 7123:5000 -t -i -v /var/imagedata:/var/imagedata southern:southernapi
(Run docker in server)

5. Access API using http://server-ip:7123/swagger/index.html




