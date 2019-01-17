echo "Installing Docker"
sudo apt-get update
apt-get install -y unzip
sudo apt-get upgrade
sudo curl -fsSL get.docker.com -o get-docker.sh
sudo sh get-docker.sh
sudo rm get-docker.sh

echo "Installing Nomad"
NOMAD_VERSION=0.8.6
cd /tmp/
curl -sSL https://releases.hashicorp.com/nomad/${NOMAD_VERSION}/nomad_${NOMAD_VERSION}_linux_amd64.zip -o nomad.zip
unzip nomad.zip
sudo install nomad /usr/bin/nomad
sudo mkdir -p /etc/nomad.d
sudo chmod a+w /etc/nomad.d

echo "Installing Consul"
apt-get update
wget https://releases.hashicorp.com/consul/1.4.0/consul_1.4.0_linux_amd64.zip -O consul.zip --quiet
unzip consul.zip >/dev/null
chmod +x consul
#run consul
echo "Running Consul"
./consul agent -dev -enable-script-checks -bind "192.168.33.12" -join "192.168.33.10" -node=node2 -client "0.0.0.0" > logs.consul &
    
for bin in cfssl cfssl-certinfo cfssljson
do
  echo "Installing $bin..."
  curl -sSL https://pkg.cfssl.org/R1.2/${bin}_linux-amd64 > /tmp/${bin}
  sudo install /tmp/${bin} /usr/local/bin/${bin}
done
nomad -autocomplete-install
nomad agent -dev -dc="dc2" -bootstrap-expect=3 > logs.nomad &