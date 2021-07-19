docker build -t service.localisation . ;
docker tag service.localisation mateusz9090/localisation:local ;
docker push mateusz9090/localisation:local