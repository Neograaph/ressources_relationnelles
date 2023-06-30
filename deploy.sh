# docker compose up -d

# cd ApiCube

# docker build -t neo/migrations:1 -f dockerfile.migrations .

# docker run -d -it --net=ressources_relationnelles_default -e DATABASE_URL=mysql://root:123@db:3306/cubeDatabase neo/migrations:1 bash

# ==> dans le container :

# apt update

# apt install iputils-ping (ping)

# ping db

# cd Apicube 

# dotnet ef database update