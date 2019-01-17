job "kubeweb" {

  datacenters = ["dc0"]
  type = "service"

  update {
    max_parallel = 1
    min_healthy_time = "10s"
    healthy_deadline = "3m"
    progress_deadline = "10m"
    auto_revert = false
    canary = 0
  }

  migrate {
    max_parallel = 1
    health_check = "checks"
    min_healthy_time = "10s"
    healthy_deadline = "5m"
  }

  group "webapp" {
    count = 1
    restart {
      attempts = 2
      interval = "30m"
      delay = "15s"
      mode = "fail"
    }

    ephemeral_disk {
      size = 300
    }

    task "kubeweb" {
      driver = "docker"
      
      config {
        image = "krystiankolad/kube.web"
        port_map {
          web = 5000
        }
      }

      resources {
        cpu    = 500 # 500 MHz
        memory = 256 # 256MB
        network {
          mbits = 10
          port "web" {
            static = 5000
          }
        }
      }

      service {
        name = "kubeweb"
        tags = ["global", "web"]
        port = "web"
        check {
          name     = "alive"
          type     = "tcp"
          interval = "10s"
          timeout  = "2s"
        }
      }
    }
  }
}