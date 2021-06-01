$appname = "ecom-web:v0.0.1"
$deploymentName = "ecom-web-app-deployment"
$serviceName = "ecom-webapp-service"

kubectl delete deployment $deploymentName --context kind-ecom

kubectl delete svc $serviceName --context kind-ecom

docker build -t $appname -f ..\src\Web\ecomApp\Dockerfile ..\src\Web\ecomApp

kind load docker-image $appname --name ecom

kubectl apply -f .\web-app-kind.yml --context kind-ecom

