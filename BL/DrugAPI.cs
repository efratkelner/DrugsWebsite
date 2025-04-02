using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    
    public class DrugAPI
    {
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class UserInput
    {
        public List<string> sources { get; set; }
        public List<string> rxcuis { get; set; }
    }

    public class MinConcept
    {
        public string rxcui { get; set; }
        public string name { get; set; }
        public string tty { get; set; }
    }

    public class MinConceptItem
    {
        public string rxcui { get; set; }
        public string name { get; set; }
        public string tty { get; set; }
    }

    public class SourceConceptItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class InteractionConcept
    {
        public MinConceptItem minConceptItem { get; set; }
        public SourceConceptItem sourceConceptItem { get; set; }
    }

    public class InteractionPair
    {
        public List<InteractionConcept> interactionConcept { get; set; }
        public string severity { get; set; }
        public string description { get; set; }
    }

    public class FullInteractionType
    {
        public string comment { get; set; }
        public List<MinConcept> minConcept { get; set; }
        public List<InteractionPair> interactionPair { get; set; }
    }

    public class FullInteractionTypeGroup
    {
        public string sourceDisclaimer { get; set; }
        public string sourceName { get; set; }
        public List<FullInteractionType> fullInteractionType { get; set; }
    }

    public class Root
    {
        public string nlmDisclaimer { get; set; }
        public UserInput userInput { get; set; }
        public List<FullInteractionTypeGroup> fullInteractionTypeGroup { get; set; }
    }

}
