Nomad
=========

Set up your Nomad environment with vagrant!

1. Run machines (```vagrant up```)
2. Connect to master (```vagrant ssh master```)
3. Go to playground (```cd /playground```)
4. Run app with ```nomad run mongodb.nomad```, ```nomad run kubeapi.nomad```, ```nomad run kubeweb.nomad```
5. Clean up (```vagrant destroy -f```)!