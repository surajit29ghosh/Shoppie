$appname = "ecom-cart-api:v0.0.1"
$deploymentName = "cart-api-deployment"
$serviceName = "cartapi-service"

kubectl delete deployment $deploymentName --context kind-ecom

kubectl delete svc $serviceName --context kind-ecom

docker build -t $appname -f ..\src\Services\Cart\API\Dockerfile ..

kind load docker-image $appname --name ecom

kubectl apply -f .\cart-api-kind.yml --context kind-ecom

