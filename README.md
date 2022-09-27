# simply_lexical_analysis
simply lexical analysis made with python<br/>
<h1>Ex:</h1>
"1+1=2"  is <br/>
['dig', '+', 'dig', '=', 'dig', '\n'] <br/>
['1', '+', '1', '=', '2', '\n']<br/>
< digit,1 ><br/>
< op,+ ><br/>
< digit,1 ><br/>
< relop,= ><br/>
< digit,2 ><br/>
<p>---------------------------------------------------------------</p>
1w+w1=2 is<br/>
['dig', 'lett', '+', 'lett', 'dig', '=', 'dig', '\n']<br/>
['1', 'w', '+', 'w', '1', '=', '2', '\n']<br/>
< DigitERR,1w ><br/>
< op,+ ><br/>
< ID,w1 ><br/>
< relop,= ><br/>
< digit,2 ><br/>
<h1>DFA</h1><br/>
<img src="./erd-Page-3.drawio.png"/>
