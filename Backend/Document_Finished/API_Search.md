# �����û���������

�����ַ��/api/Search/Search_user

����ʽ��Get

�������ͣ�string keyword

���ؽ����
�û��б�User_list
|״̬��  |˵��        |
| string | ID         |
| string | Email      |
| string | Password   |
| string | Username   |
| string | Bio        |
| string | Photo      |
| string | FollowState��TrueΪ�ѹ�ע��FalseΪδ��ע����
|Not found|δ�ҵ��û� |



# ������̬����ǩ��������

�����ַ��/api/Search/Search_all

����ʽ��Get

�������ͣ�string keyword

���ؽ����
|״̬��  |    ˵��    |

����ǩ�б�:tags
| string | UserID  |
| string | Tag     |
| string | FollowState��TrueΪ�ѹ�ע��FalseΪδ��ע�� |

����̬�б�:moments
| string | ID          |
| string | Sender_Id   |
| string | Content     |
| int    | Like_num    |
| int    | Forward_num |
| int    | Collect_num |
| int    | Comment_num |
|string  | time        |
|null    |δ�ҵ��κ�������� |