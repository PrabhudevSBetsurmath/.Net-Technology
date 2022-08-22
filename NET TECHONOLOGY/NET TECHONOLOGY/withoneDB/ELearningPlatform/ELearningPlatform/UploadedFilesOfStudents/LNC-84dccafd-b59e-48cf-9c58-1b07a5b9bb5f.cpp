#include<bits/stdc++.h>
# define ll long long int
using namespace std;

void dfs(int &count,string& input,map<string,vector<string>>&m,vector<string>& result)
{
    if(count==m[input].size())return;   //if all neighbors visited return

    result.push_back(m[input][count]); // add the neighbor in the result vector

    count++;                        //increment the count to point to next neighbor

    dfs(count,input,m,result);      //recursive call till all the neighbors are visited
}
void tester(map<string,vector<string>>&m)
{
    ll testcases;
    cin>>testcases;          //take number of testcases as input from user   
    while(testcases--)
    {
        string input;
        cin>>input;                 //country name as input
        
        vector<string>res;    //auxilary array for storing the neighboring countries

        int count=0;

        dfs(count,input,m,res);      //dfs call 
        
        if(res.size()==0)        //no neighbors found for the input country
        {
            cout<<"Please Try Again\n";
            return;
        }
        for(int i=0;i<res.size();i++)
        cout<<res[i]<<" ";                  //print the result
        cout<<endl;

    }
} 
int main()
{
    map<string,vector<string>>m;
    
    m["india"].push_back("pakistan");
    m["india"].push_back("china");
    m["india"].push_back("nepal");
    m["china"].push_back("india");
    m["china"].push_back("nepal");
    m["china"].push_back("pakistan");
    m["china"].push_back("afghanistan");
    m["pakistan"].push_back("nepal");
    m["pakistan"].push_back("india");
    
    tester(m);

    
}