Syncing Consul and kubernetes
======

To sync our consul and kubernetes services we need to follow this steps(commands to run when we are in infrastructure folder):
1. Run consul service (kubectl apply -f consul.yaml)
2. Add admin role to default account (kubectl apply -f account.yaml)
3. Run sync pod (kubectl apply -f sync-pod.yaml). It is syncing our consul and kubernetes services.
4. Run any service we want. Remember that service must have external port. After few seconds service should be registered in consul and kubernetes.