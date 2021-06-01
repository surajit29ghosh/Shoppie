$appname = "ecom-product-api:v0.0.1"
$deploymentName = "product-api-deployment"
$serviceName = "productapi-service"

kubectl delete deployment $deploymentName --context kind-ecom

kubectl delete svc $serviceName --context kind-ecom

docker build -t $appname -f ..\src\Services\Product\API\Dockerfile ..

kind load docker-image $appname --name ecom

kubectl apply -f .\product-api-kind.yml --context kind-ecom

