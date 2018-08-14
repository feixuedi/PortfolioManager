# PortfolioManager

## 1. API Design

### 1.1 User Management

#### 1.1.1 login
* method: post
* url: /api/login
* content: {'soeid' : 'test', 'passwd' : 'test'}
* return: {'status' : 'ok', 'name' : 'Aaron', 'type' : 'administrator'}

### 1.2 Fund Managers Management

#### 1.2.1 get fund managers
* method: get
* url: /api/managers
* params: {}
* return: {'status' : 'ok', 'managers' : \[{'soeid': 'test', 'name': 'Aaron', }, {}, ...\]}

#### 1.2.2 add a fund manager
* method: post
* url: /api/managers/add
* content: {'soied' : 'test', 'name' : 'Aaron', 'password' : '123456', 'limit' : 100000}
* return: {'status' : 'ok'}

#### 1.2.3 delete a fund manager
* method: post
* url: /api/managers/delete
* content: {'soeid' : 'test'}
* return: {'status' : 'ok'}

#### 1.2.4 update manager's limit
* method: post
* url: /api/managers/limit
* content: {'soeid' : 'test', 'limit' : 100000}
* return: {'status' : 'ok'}

#### 1.2.5 get manager's performance
* method: get
* url: /api/managers/performance
* params: {}
* return: {'status' : 'ok', performance : \[{'soeid' : 'test', 'name' : 'Aaron', 'profit' : 100000}, {}, ...\]}

#### 1.2.6 upload data
* method: post
* url: /api/managers/data
* content: file
* return: {'status' : 'ok'}

### 1.3 Portfolios Management

#### 1.3.1 get all portfolios
* method: get
* url: /api/portfoios
* params: {'soeid' : 'test'}
* return: {'status' : 'ok', 'portfolios' : \[{'name' : 'portfolio1', 'limit' : 100000, 'crash' : 50000, 'policy' : 'fifo', 'createDate' : '2017-12-01'}, {}, ...\]}

#### 1.3.2 