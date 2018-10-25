Swarm
========

Create your environment with swarm!

1. Run machines (```vagrant up```)
2. Connect to master (```vagrant ssh master```), init swarm (```docker swarm init --advertise-addr 192.168.33.10:2378 --listen-addr 192.168.33.10:2377```)
3. Connect to node1 (```vagrant ssh node1```), join swarm (```docker swarm join```)(Remember to use addres specified in --listen-addr in step 2 instead of advertise-addr)
4. Connect to node2 (```vagrant ssh node2```), join swarm (```docker swarm join```)(Remember to use addres specified in --listen-addr in step 2 instead of advertise-addr)
5. After tests clean up (```vagrant destroy -f```)