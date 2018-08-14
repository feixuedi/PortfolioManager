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
* url: /api/portfolios
* params: {'soeid' : 'test'}
* return: {'status' : 'ok', 'portfolios' : \[{'name' : 'portfolio1', 'limit' : 100000, 'cash' : 50000, 'policy' : 'fifo', 'createdDate' : '2017-12-01', 'profit' : 10000}, {}, ...\]}

#### 1.3.2 get a portfolio
* method: get
* url: /api/portfolios/portfolio
* params: {'ptfid' : 1}
* return: {'status': 'ok', 'name' : 'portfolio1', 'limit' : 100000, 'cash' : 50000, 'policy' : 'fifo', 'createdDate' : '2017-12-01'}

#### 1.3.3 add a portfolio
* method: post
* url: /api/portfolios/add
* content: {'name' : 'Aaron', 'soeid' : 'test', 'limit' : 100000, 'policy' : 'fifo'}
* return: {'status' : 'ok'}

#### 1.3.4 delete a portfolio
* method: post
* url: /api/portfolios/delete
* content: {'ptfid' : 1}
* return: {'status' : 'ok'}

#### 1.3.5 update a portfolio
* method: post
* url: /api/portfolios/update
* content: {'name' : 'portfolio1', 'limit' : 100000, 'cash' : 50000, 'policy' : 'fifo'}
* return: {'status' : 'ok'}

#### 1.3.6 get portfolio profit by manager for louise
* method: get
* url: /api/portfolios/manager-profit
* params: {'soeid' : 'test'}
* return: {'status' : 'ok', 'profit' : \[{'ptfid' : 1, 'name' : 'portfolio1', 'profit' : 10000}, {}, ...\]}

#### 1.3.7 delegate a portfolio
* method: post
* url: /api/portfolios/delegate
* content: {'fromSoeid' : 'test1', 'toSoeid' : 'test2', 'ptfid' : '1'}
* return: {'status' : 'ok'}

### 1.4 Profit Data

#### 1.4.1 get manager's profit for kate index header
* method: get
* url: /api/profit/bymanager
* param: {'soeid' : 'test'}
* return: {'status' : 'ok', 'portfolioNum' : 2, 'totalReturn' : 0.07, 'dailyReturn' : 0.01, '20dayReturn' : 0.02, '100dayReturn' : 0.08}

#### 1.4.2 get profit by date for kate index middle chart
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
					'ptfName' : 'portfolio1',
					'dates' : ['2017-01-01', '2017-01-02', '2017-01-03', '2017-01-04', '2017-01-05'],
					'values' : [0.01, 0.02, 0.03, 0.02, 0.04 ]
				},
				{},
				...
			   ]
	}

#### 1.4.3 get portfolios' profit for kate index bottom
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
				'createdDate' : '2017-01-01'
			}, 
			{}, 
			...
		   ]
	}

#### 1.4.4 sort portfolio's return rate for kate index middle list
* method: 'get'
* url: /api/proifit/sort
* param: {'soeid' : 'test'}
* return:
***
    {
    'status' : 'ok',
    'portfolioNames' :
        [
            'portfolio1',
            'portfolio2'
        ]
    }

### 1.5 Portfolio Data

#### 1.5.1 get portfolio's data for kate portfolio header
* method: get
* url: /api/positions/data
* param: {"ptfid" : 1}
* return: 
***
    {
        "status" : "ok",
        "totalAsset" : 200000.00,
        "totalReturn" : 0.07,
        "dailyReturn" : 0.01,
        "20dayReturn" : 0.02,
        "100dayReturn" : 0.08,
        "cash": 15.57,
        "policy": "fifo"
    }
 
#### 1.5.2 get profits by date for kate portfolio middle chart
* method: get
* url: /api/positions/profit
* param: {"ptfid" : 1, "startDate" : "2017-04-01", "endDate" : "2017-06-01"}
* return: 
***
	{
		"status" : "ok",
		"profit" : [
				{
					"posid' : 1,
					"symbol" : "AAPL",
					"dates" : ["2017-01-01", "2017-01-02", "2017-01-03", "2017-01-04", "2017-01-05"],
					"values' : [0.01, 0.02, 0.03, 0.02, 0.04 ]
				},
				...
		   ]
	}

#### 1.5.3 sort position by profit date for kate portfolio middle list
* method: get
* url: /api/positions/sort
* param: {"ptfid": 1}
* return:
***
    {"status": "ok",
    "symbolNames": ["AAPL", "C"]
    }

#### 1.5.4 position details for kate portfolio middle-bottom left list and trade bottom right list
* method: get
* url: /api/positions/details
* param: {"ptfid": 1}
* return:
***
    {"status": "ok",
    "positions": [
        {
        "symbol": "AAPL",
        "latesPrice": 15.49,
        "bidPrice": 13.79,
        "qty": 1000,        
        "durationDays": 15,
        "latestValue": 1549
        },
        ...
        ]
    }

#### 1.5.5 for kate portfolio middle-bottom middle pie chart
* method: get
* url: /api/positions/percent
* param: {"ptfid": 1}
* return:
***
    {"status": "ok",
    "percents": [
        {
        "symbol": "AAPL",
        "value": 15.7
        },
        ...
        ]
    }

#### 1.5.6 for kate portfolio middle-bottom middle pie chart
* method: get
* url: /api/positions/typePercent
* param: {"ptfid": 1}
* return:
***
    {"status": "ok",
    "percents": [
        {
        "type": "Commodities",
        "value": 15.7
        },
        ...
        ]
    }

#### 1.5.7 view trade histroy for kate portfolio bottom left list
* method: get
* url: /api/positions/histroy
* param: {"ptfid": 1}
* return:
***
    {"status": "ok",
    "trades": [
        {
        "symbol": "AAPL",
        "price": 15.7,
        "date": 20,
        "type": "buy",
        "qty": 150
        },
        ...
        ]
    }

### 1.6 Trade

#### 1.6.1 view symbol for kate portfolio bottom right chart
* method: get
* url: /api/symbol/histroy
* param: {"symbol": "AAPL", "startDate": "2017-12-01", "endDate": "2017-12-10"}
* return:
***
    {"status": "ok",
    "dates": ["2017-12-01", "2017-12-03", "2017-12-05", "2017-12-07", "2017-12-09"]
    "values": [153.54,153.79,154.13,152.67,153.00]
    }

#### 1.6.2 view symbol detail for kate trade middle list
* method: get
* url: /api/symbol/detail
* param: {"symbol": "AAPL"}
* return:
***
    {
        "status": "ok",
        "latestPrice": 151.00,
        "openPrice": 150.00,
        "lowestPrice": 149.79,
        "highestPrice": 151.11,
        "volume": 1008,
        "changeRate": 7.5
    }

#### 1.6.3 view all symbol within a type for kate trade middle 
* method: get
* url: /api/symbol/detail
* param: {"type": "commodities"}
* return:
***
    {
        "symbols": ["AAPL", "C", ...]
    }

