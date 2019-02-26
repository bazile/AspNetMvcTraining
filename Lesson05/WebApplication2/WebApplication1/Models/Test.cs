using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplication2.Models
{
    // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
    /// <remarks/>
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("quizzes", Namespace = "", IsNullable = false)]
    public partial class Quizzes
    {

        private Quizz[] quizField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("quiz")]
        public Quizz[] AllQuizzes
        {
            get
            {
                return this.quizField;
            }
            set
            {
                this.quizField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Quizz
    {
        private Question[] qField;
        private string nameField;

        [XmlIgnore]
        public int Index { get; set; }

        /// <remarks/>
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("q")]
        public Question[] Questions
        {
            get
            {
                return this.qField;
            }
            set
            {
                this.qField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute("name")]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Question
    {

        private Answer[] aField;

        private string textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("a")]
        public Answer[] Answers
        {
            get
            {
                return this.aField;
            }
            set
            {
                this.aField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute("text")]
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        [XmlIgnore]
        public int Index { get; internal set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Answer
    {

        private string textField;

        private string correctField;

        private string valueField;

        /// <remarks/>
        [XmlAttribute("text")]
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string correct
        {
            get
            {
                return this.correctField;
            }
            set
            {
                this.correctField = value;
            }
        }

        [XmlIgnore]
        public bool IsCorrect
        {
            get { return correctField == "yes"; }
            set { correctField = value ? "yes" : null; }
        }


        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        [XmlIgnore]
        public int Index { get; internal set; }
    }
}
