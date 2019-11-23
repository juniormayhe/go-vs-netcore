
Junior@DESKTOP-0DL2BTS MINGW64 ~/go/src

## Setup your enviroment
```
docker pull mysql
docker run -p 3306:3306 --name some-mysql -e MYSQL_ROOT_PASSWORD=12345 -d mysql:latest
create a demo database in mysql

##
```
cd ~/go/src/go
go get -u github.com/gin-gonic/gin
go get gopkg.in/gin-gonic/gin.v1
go get github.com/go-sql-driver/mysql
go get -u github.com/jinzhu/gorm
go get -u github.com/codesenberg/bombardier
go run main.go
```

## Golang 1.12.7
```
$ bombardier -c 125 -n 500000 http://localhost:8080/v1/api/todos
Bombarding http://localhost:8080/v1/api/todos with 500000 request(s) using 125 connection(s)
 500000 / 500000  100.00% 2574/s 3m14s
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec      2577.86    1481.44    5601.18
  Latency       48.50ms     3.76ms   304.00ms
  HTTP codes:
    1xx - 0, 2xx - 0, 3xx - 0, 4xx - 500000, 5xx - 0
    others - 0
  Throughput:   505.79KB/s
```

## Golang 1.13.4
```
Junior@DESKTOP-0DL2BTS MINGW64 ~/go/src
$ bombardier -c 125 -n 500000 http://localhost:8080/v1/api/todos
Bombarding http://localhost:8080/v1/api/todos with 500000 request(s) using 125 connection(s)
 500000 / 500000  100.00% 2634/s 3m9ss
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec      2637.04    1484.31    7012.62
  Latency       47.41ms     4.74ms   318.00ms
  HTTP codes:
    1xx - 0, 2xx - 0, 3xx - 0, 4xx - 500000, 5xx - 0
    others - 0
  Throughput:   517.46KB/s
```

## Netcore 2.1
```
Junior@DESKTOP-0DL2BTS MINGW64 ~/go/src
$ bombardier -c 125 -n 500000 http://localhost:5001/todo
Bombarding http://localhost:5001/todo with 500000 request(s) using 125 connectio   n(s)
 500000 / 500000  100.00% 1362/s 6m7ss
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec      1362.85     845.11    6713.10
  Latency       91.70ms    40.71ms      4.50s
  HTTP codes:
    1xx - 0, 2xx - 500000, 3xx - 0, 4xx - 0, 5xx - 0
    others - 0
  Throughput:   457.84KB/s
```

## Netcore 2.2
```
Junior@DESKTOP-0DL2BTS MINGW64 ~/go/src
$ bombardier -c 125 -n 500000 http://localhost:5003/todo
Bombarding http://localhost:5003/todo with 500000 request(s) using 125 connection(s)
 500000 / 500000  100.00% 1707/s 4m52s
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec      1708.14     883.62    6709.67
  Latency       73.16ms    19.82ms      1.60s
  HTTP codes:
    1xx - 0, 2xx - 500000, 3xx - 0, 4xx - 0, 5xx - 0
    others - 0
  Throughput:   573.86KB/s
```

## Netcore 3.0
```
$ bombardier -c 125 -n 500000 http://localhost:5000/todo
Bombarding http://localhost:5000/todo with 500000 request(s) using 125 connection(s)
 500000 / 500000  100.00% 1691/s 4m55s
Done!
Statistics        Avg      Stdev        Max
  Reqs/sec      1691.85     847.78    6098.14
  Latency       73.84ms   193.35ms      9.61s
  HTTP codes:
    1xx - 0, 2xx - 500000, 3xx - 0, 4xx - 0, 5xx - 0
    others - 0
  Throughput:   568.82KB/s
```