job "cronjob" {

  datacenters = ["dc1"]
  type = "batch"

  periodic {
    cron             = "0/5 * * * *"
    prohibit_overlap = false
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

    task "cronjob" {
      driver = "docker"
      config {
        image = "krystiankolad/kube.job"
      }

      resources {
        cpu    = 500 # 500 MHz
        memory = 256 # 256MB
        network {
          mbits = 10
        }
      }
    }
  }
}