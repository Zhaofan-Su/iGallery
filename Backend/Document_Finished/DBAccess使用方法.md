������ÿ���������о�����ͣ������Ŀ���������

��Ҫ�������ݿ�ʱ���ȴ���һ��DBAccess����
����DBAccess   Access = new  DBAccess();
֮�����ֱ�ӵ��ú������в���������Ҫ���Ǵ��Լ��ر����ݿ⡣

public DataSet GetDataSet(string sql, string DataSetName)
�ú����������ݿ��и���������ݷŽ�DataSet�У�
ֱ�Ӵ���һ��DataSet����
����DataSet set = Access.GetDataSet(sql, "�˴�Ϊ���ݿ��б���");
������foreachһ����ѭ����¼��foreach(var row in set.Tables[0].Rows)
Ȼ��row["������"]����ֱ�ӵõ�����ĳ�е�����

public DataSet GetDataSet(string sql, string DataSetName, int PageSize, int CurrentPage)
�ú����õ����з�ҳ���ܵ�DataSet��
��ҳ������ָ��ǰ��Ҫչʾ�ܶණ����ʱ�򣬽��з�ҳ���᷵�ص�ǰҳ�ţ��Լ�ÿҳ����������


public OracleDataReader GetDataReader(string sql)
�ú���ʹ��select����ȡ���ݿ⣬ʹ��ǰҪʹ��һ��Read().
���������DataSet�ɿ��������

public int GetRecordCount(string sql)
����select����ȡ�ļ�¼�����������Լ����¼��Ŀ

public bool ExecuteSql(string sql)
�ж���ɾ������Ƿ�ִ�гɹ�

public string Select(string Colums,string TableName,string Condition)
����select��䣬�������壬�����������ݼ���

public string Update(string TableName,string Result,string Condition)
����update���

public string Insert(string TableName,string Result)
����insert���

public string Insert(string TableName,string Colums,string Result)
����insert��䣬����

public string Delete(string TableName,string Conditions)
����delete���

