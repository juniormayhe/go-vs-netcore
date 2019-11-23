
# Go vs Netcore REST API performance comparison

Here a quick performance test using bombardier to evaluate requests per second, latency and throughput of go (with gin) and netcore.  

![](https://media.giphy.com/media/wIV2gwOkpZeBG/giphy.gif)

## Setup your enviroment

### Prepare your mysql data
```
docker pull mysql
docker run -p 3306:3306 --name some-mysql -e MYSQL_ROOT_PASSWORD=12345 -d mysql:latest
```

then create a demo database in mysql

### Download go dependencies for gin

```
cd ~/go/src/go
go get -u github.com/gin-gonic/gin
go get gopkg.in/gin-gonic/gin.v1
go get github.com/go-sql-driver/mysql
go get -u github.com/jinzhu/gorm
```

### Get benchmark tool
```
go get -u github.com/codesenberg/bombardier
```

## Running go

Run REST API in go before running bombardier for benchmarking go
```
go run main.go
```

## Benchmarking

### Golang 1.12.7
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

### Golang 1.13.4
```
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

### Netcore 2.1

Use Visual Studio or dotnet run to execute netcore REST api.

```
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

### Netcore 2.2
```
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

### Netcore 3.0
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

  

## TL;DR

Best HTTP requests per second, higher is better

| Language | Requests/sec |
|  --- | ---  |
| go 1.13.4 | 2637.04 :arrow_up_small:|
| go 1.12.7 | 2577.86 |
| netcore 2.2 | 1708.14 |
| netcore 3.0 | 1691.85 |
| netcore 2.1 | 1362.85 |

Best HTTP latency, lower is better

| Language | ms |
| --- | --- |
| go 1.13.4 | 47.41 :arrow_up_small:|
| go 1.12.7 | 48.50 |
| netcore 2.2 | 73.16 |
| netcore 3.0 | 73.84 |
| netcore 2.1 | 91.70 |

Best HTTP throughput, higher is better
  
| Language  | KB/s |
|--|--|
| netcore 2.2 | 573.86 :arrow_up_small: |
| netcore 3.0 | 568.82 |
| go 1.13.4 | 517.46 |
| go 1.12.7 | 505.79 |
| netcore 2.1 | 457.84 |