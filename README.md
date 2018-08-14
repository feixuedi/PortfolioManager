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
* return: {'status' : 'ok', 'managers' : \[{'soeid': 'test', 'name': 'Aaron', 'limit' : 100000, 'profit' : 10000}, {}, ...\]}

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
* return: {'status' : 'ok', 'portfolios' : \[{'name' : 'portfolio1', 'limit' : 100000, 'crash' : 50000, 'policy' : 'fifo', 'createDate' : '2017-12-01', 'profit' : 10000}, {}, ...\]}

#### 1.3.2 get a portfolio
* method: get
* url: /api/portfolios/portfolio
* params: {'ptfid' : 1}
* return: {'status': 'ok', 'name' : 'portfolio1', 'limit' : 100000, 'crash' : 50000, 'policy' : 'fifo', 'createDate' : '2017-12-01'}

#### 1.3.3 add a portfolio
* method: post
* url: /api/portfolios/add
* content: {'name' : 'Aaron', 'soeid' : 'test', 'limit' : 100000, 'policy' : 'fifo'}
* return: {'status' : 'ok'}

#### 1.3.4 delete a portfolio
* method: post
* url: /api/portfolios/delete
* content: {'soeid' : 'test', 'ptfid' : 1}
* return: {'status' : 'ok'}

#### 1.3.5 update a portfolio
* method: post
* url: /api/portfolios/update
* content: {'name' : 'portfolio1', 'limit' : 100000, 'crash' : 50000, 'policy' : 'fifo', 'createDate' : '2017-12-01'}
* return: {'status' : 'ok'}

#### 1.3.6 get portfolio profit by manager
* method: get
* url: /api/portfolios/manager-profit
* params: {'soeid' : 'test',}
* return: {'status' : 'ok', 'profit' : \[{'ptfid' : 1, 'name' : 'portfolio1', 'profit' : 10000}, {}, ...\]}

#### 1.3.7 delegate a portfolio
* method: post
* url: /api/portfolios/delegate
* content: {'fromSoeid' : 'test1', 'toSoeid' : 'test2', 'ptfid' : '1'}
* return: {'status' : 'ok'}

### 1.4 Profit Data

#### 1.4.1 get manager's profit
* method: get
* url: /api/profit/bymanager
* param: {'soeid' : 'test'}
* return: {'status' : 'ok', 'portfolioNum' : 2, 'totalReturn' : 0.07, 'dailyReturn' : 0.01, '20dayReturn' : 0.02, '100dayReturn' : 0.08}

#### 1.4.2 get profit by date
* method: get
* url: /api/profit/bydate
* param: {'soeid' : 'test', 'startDate' : '2017-04-01', 'endDate' : '2017-06-01'}
* return: 
***
	{
		'status' : 'ok',
		'profit' : [
				{
					'ptfid' : 1,
					'ptfName' : 'portfolio1'
					'days' : 5,
					'values' : [ 0.01, 0.02, 0.03, 0.02, 0.04 ]
				},
				{},
				...
			   ]
	}
	
#### 1.4.3 get portfolios' profit
* method: 'get'
* url: /api/profit/byprofolio
* param: {'soeid' : 'test'}
* return: 
***
	{
	'status' : 'ok', 
	'profit' : [
			{
				'ptfid' : 1,
				'ptfName' : 'portfolio1', 
				'totalReturn' : 0.01, 
				'dailyReturn' : 0.01, 
				'20dayReturn' : '0.01', 
				'100dayReturn' : 0.01, 
				'creationDate' : '2017-01-01'
			}, 
			{}, 
			...
		   ]
	}
