vagrant up
minikube start
(cd ../../Kubernetes/infrastructure; kubectl apply -f account.yaml)
(cd ../../Kubernetes/infrastructure; kubectl apply -f sync-pod.yaml)