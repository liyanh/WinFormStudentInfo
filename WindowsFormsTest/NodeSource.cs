using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTest
{
    class NodeSource
    {
        public static NodeSource nodeSource = new NodeSource();
        private List<NodeInfo> nodeList;
        private NodeSource()
        {
            nodeList = initNodeList();
        }

        private List<NodeInfo> initNodeList()
        {
            List<NodeInfo> init = new List<NodeInfo>();
            init.Add(new NodeInfo()
            {
                Id = 1,
                Grade = 0,
                Class = 0,
                Name = "全部",
                ParentId = 0
            });

            int id = 2;
            for(int grade = 1; grade <= 3; grade++)
            {
                init.Add(new NodeInfo()
                {
                    Id = id,
                    Grade = grade,
                    Class = 0,
                    Name = grade + "年级",
                    ParentId = 1
                });
                id++;
            }

            for (int grade = 1; grade <= 3; grade++)
            {
                for (int clas = 1; clas <= 10; clas++)
                {
                    init.Add(new NodeInfo()
                    {
                        Id = id,
                        Grade = grade,
                        Class = clas,
                        Name = clas + "班",
                        ParentId = grade + 1
                    });
                    id++;
                }
            }
            return init;
        }

        public List<NodeInfo> GetChildNodeList(int id)
        {
            List<NodeInfo> childList = new List<NodeInfo>();
            foreach (NodeInfo node in this.nodeList)
            {
                if(node.ParentId == id)
                {
                    childList.Add(node);
                }
            }
            return childList;
        }
    }
}
