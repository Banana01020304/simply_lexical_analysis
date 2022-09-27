a = "1+1=2"
_type = []
_val=[]
st_fin=[]
state_ch = 0

for i in a:
    try:
       _type.append(i if i in  ["<",">","="] else "dig" if int(i) in range(10) else i if i in ["+","-","*","/"] else "lett")
       _val.append(i if i in  ["<",">","="] else i if int(i) in range(10) else i if i in ["+","-","*","/"] else i)
    except:
       _type.append(i if i in  ["<",">","="]  else i if i in ["+","-","*","/"] else "lett")
       _val.append(i if i in  ["<",">","="]  else i if i in ["+","-","*","/"] else i)
_type.append('\n')
_val.append('\n')
print(_type)
print(_val)
dfa = {0:{'dig':1, 'lett':2,'+':3,'-':4,'*':5,'/':6,'<':7,'>':8,'=':9,'other':30}, #11 = err ; 13=ret op
       1:{'dig':1, 'other':10,'lett':31},
       31:{'lett':31, 'dig':31, 'other':14},
       2:{'lett':2, 'dig':2, 'other':12},
       3:{'other':13,'+':11,'-':11,'*':11,'/':11,'<':11,'>':11,'=':11},
       4:{'other':13,'+':11,'-':11,'*':11,'/':11,'<':11,'>':11,'=':11},
       5:{'other':13,'+':11,'-':11,'*':11,'/':11,'<':11,'>':11,'=':11},
       6:{'other':13,'+':11,'-':11,'*':11,'/':11,'<':11,'>':11,'=':11},
       7:{'>':21,'=':22,'other':23,'<':11},
       8:{'=':25,'other':26,'<':11,'>':11},
       9:{'<':11,'>':11,'=':11,'other':29},
       10:{'dig':1, 'lett':2,'+':3,'-':4,'*':5,'/':6,'<':7,'>':8,'=':9,'other':0},
      
       11:{'dig':1, 'lett':2,'+':3,'-':4,'*':5,'/':6,'<':7,'>':8,'=':9,'other':0},
       
       12:{'dig':1, 'lett':2,'+':3,'-':4,'*':5,'/':6,'<':7,'>':8,'=':9,'other':0},
       13:{'dig':1, 'lett':2,'+':3,'-':4,'*':5,'/':6,'<':7,'>':8,'=':9,'other':0},
       14:{'dig':14, 'lett':14,'+':3,'-':4,'*':5,'/':6,'<':7,'>':8,'=':9,'other':0},
       21:{'other':0}, #
       22:{'other':0}, #
       23:{'dig':1, 'lett':2,'+':3,'-':4,'*':5,'/':6,'<':7,'>':8,'=':9,'other':0},
      
       25:{'other':0}, #
       26:{'dig':1, 'lett':2,'+':3,'-':4,'*':5,'/':6,'<':7,'>':8,'=':9,'other':0},
       27:{'dig':1, 'lett':2,'+':3,'-':4,'*':5,'/':6,'<':7,'>':8,'=':9,'other':0},
       28:{'dig':1, 'lett':2,'+':3,'-':4,'*':5,'/':6,'<':7,'>':8,'=':9,'other':0},
       29:{'dig':1, 'lett':2,'+':3,'-':4,'*':5,'/':6,'<':7,'>':8,'=':9,'other':0},
       30:{'other':0}
       }
fin_stage_map={
            10:"digit",
            11:"OpERR",
            14:"DigitERR",
            12:"ID",
            13:"op",
            21:"relop",#!=
            22:"relop",#<=
            23:"relop",#<
            25:"relop",#>=
            26:"relop",#>
            29:"relop",#=
            30:"ERR",

        }
def accepts(transitions,initial,accepting,s,_val):
    state = initial
    state_travel=[]
    val_=[]
    num_elm_s = len(s)
    i=0
    while i< num_elm_s:
        print(state)
        try:
            state = transitions[state][s[i]]
            val_.append(_val[i])
            i+=1
        except:
            state = transitions[state]['other']
            
            i+=1
        if state in accepting:
            if state !=11 and state !=31:
                i-=1
                state_travel.append( [state in accepting , fin_stage_map[state],state])
                val_.append(_val[i])
                val_.append(',')
            else:
                state_travel.append( [state in accepting , fin_stage_map[state],state])
                val_.append(_val[i])
                val_.append(',')
    fin_val ="".join(val_).split(',')
    print(fin_val)
    fin_rem=[]
    for i in fin_val:
        fin_rem.append(i[:len(i)-1])
    return state_travel,fin_rem
fin=list(range(10,31))

acc = accepts(dfa,0,fin,_type,_val)
for i,v in enumerate( acc[0]):
    print(f"< {v[1]},{acc[1][i]} >")