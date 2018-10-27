Vagrant
=========

Set up your testing environment with vagrant!

1. Run machines (```vagrant up```)
2. Connect to master (```vagrant ssh master```), run kubernetes (```sudo kubeadm init --apiserver-advertise-address 192.168.33.10```), setup your network (```kubectl apply -f "https://cloud.weave.works/k8s/net?k8s-version=$(kubectl version | base64 | tr -d '\n')"```), setup your kubernetes router (```kubectl apply -f https://raw.githubusercontent.com/cloudnativelabs/kube-router/master/daemonset/kubeadm-kuberouter.yaml```)
3. Connect to node1 (```vagrant ssh node1```), run kubernetes (```sudo kubeadm join --token (```your token```) 192.168.33.10 --node-name worker1```)
4. Connect to node2 (```vagrant ssh node2```), run kubernetes (```sudo kubeadm join --token (```your token```) 192.168.33.10 --node-name worker2```)
5. Get rid of everything after all tests (```vagrant destroy```)


If you receive an error saying "The connection to the server localhost:8080 was refused - did you specify the right host or port?" run this three commands in your terminal:
```
sudo cp /etc/kubernetes/admin.conf $HOME/
sudo chown $(id -u):$(id -g) $HOME/admin.conf
export KUBECONFIG=$HOME/admin.conf
```