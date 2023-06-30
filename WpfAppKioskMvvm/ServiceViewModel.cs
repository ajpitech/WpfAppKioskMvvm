using ClassLibraryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEntity;

namespace WpfAppKioskMvvm
{
    public class ServiceViewModel : BaseViewModel
    {
        private  MainWindowViewModel MainWindowViewModel;
        public int CounterNo { get; set; }
        public string TokenNo { get; set; }
        public string TokenNoDetail { get; set; }
        //public ServiceViewModel()
        //{
        //    if (MainWindowViewModel != null)
        //    {
        //        QuestionWindow(MenuSelectedItem);
        //        SaveMenuCommand = new RelayCommand(saveQuestionAnswer);
        //    }

        //} 
        public ServiceViewModel(MainWindowViewModel mainWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
            if (MainWindowViewModel != null)
            {
                QuestionWindow(MainWindowViewModel.MenuSelectedItem);
                SaveMenuCommand = new RelayCommand(saveQuestionAnswer);
            }

        }

        private void saveQuestionAnswer(object obj)
        {
            List<TokenCounter> TokenList= BasicOperation.SaveToDatabase(ConvertToListDTO(QuestionList));

            if(TokenList.Count> 0)
            {
                TokenNo = TokenList[TokenList.Count-1].Tokenno;
                CounterNo  = TokenList[TokenList.Count-1].CounterNo;
            }

            TokenNoDetail = "Your Counter No is "+CounterNo+" And Token No is "+ TokenNo;
            OnPropertyChanged(nameof(TokenNoDetail));

        }
        private List<QuestionAnswers> ConvertToListDTO(List<Questions> QuestionList)
        {
            List<QuestionAnswers> QAList = new List<QuestionAnswers>();
            foreach ( Questions Que in QuestionList)
            {
                QuestionAnswers Qa = new QuestionAnswers();
                Qa.QuestionId = Que.QuestionId;
                Qa.FullAnswer = Que.FullAnswer;
                QAList.Add(Qa);
            }
            return QAList;
        }


       
        public string MenuLbl { get; set; }
        public void QuestionWindow(int Menuid)
        {
            var sm = BasicOperation.resServiceMenu.ResData.Where(x => x.MenuId == Menuid).ToList().SingleOrDefault();
            MenuLbl = "Your Choice is " + sm.MenuName + " Menu";
            QuestionList = BasicOperation.View_Question(sm.MenuId);
            OnPropertyChanged(nameof(QuestionList));
            //TokenNoDetail = "Your Counter No is";
            OnPropertyChanged(nameof(TokenNoDetail));
        }


    }
}
