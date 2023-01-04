using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CheckIfStringArrayContainsAValueAndGetIndex
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class CheckMethods
    {
        private readonly string[] _stringArray =
        {
            "dog", "cat", "bird", "horse", "pig", "cow", "sheep", "goat", "chicken", "duck", "frog", "turtle",
            "rabbit", "hamster", "mouse", "gerbil", "rat", "guinea pig", "ferret", "beaver", "otter", "skunk",
            "kangaroo", "monkey", "chimpanzee", "gorilla", "lizard", "snake", "toad", "crocodile", "alligator",
            "dolphin", "whale", "shark", "fish", "crab", "lobster", "shrimp", "octopus", "squid", "clam", "scallop",
            "oyster", "mussel", "starfish", "sponge", "jellyfish", "seagull", "penguin", "pelican", "albatross",
            "swan", "goose", "duck", "heron", "ostrich", "emu", "turkey", "peacock", "parakeet", "parrot",
            "flamingo", "pigeon", "dove", "woodpecker", "sparrow", "robin", "blue jay", "cardinal", "finch",
            "thrush", "wren", "goldfinch", "toucan", "buzzard", "eagle", "raven", "crow", "magpie", "dormouse",
            "lemur", "opossum", "panda", "koala", "sloth", "ant eater", "gopher", "marmot", "chipmunk", "nutria",
            "mink", "weasel", "badger", "wombat", "hippopotamus", "rhinoceros", "giraffe", "elephant", "zebra",
            "antelope", "camel", "llama", "alpaca", "vicuna", "gazelle", "deer", "elk", "moose", "caribou",
            "reindeer", "bison", "wild boar", "pig", "warthog", "hyena", "jackal", "coyote", "dingo", "wolf",
            "fox", "kite", "vulture", "condor", "eagle", "falcon", "hawkeye", "hornet", "wasp", "beetle", "ant",
            "bee", "termite", "mosquito", "fly", "butterfly", "moth", "caterpillar", "centipede", "millipede",
            "spider", "scorpion", "tick", "mite", "louse", "flea", "bedbug", "aphid", "cicada", "cricket",
            "locust", "grasshopper", "praying mantis", "termite", "mantis", "roach", "bee", "wasp", "hornet",
            "yellow jacket", "firefly", "lightning bug", "ladybug", "dragonfly", "damselfly", "admiral", "aurora",
            "battalion", "apple", "banana", "orange", "pear", "grape", "strawberry", "raspberry", "blueberry",
            "blackberry", "mango", "peach", "apricot", "plum", "cherry", "fig", "kiwi", "pineapple", "papaya",
            "guava", "cantaloupe", "honeydew", "watermelon", "melon", "lemon", "lime", "orange", "tangerine",
            "mandarin", "clementine", "pomegranate", "persimmon", "quince", "nectarine", "arugula", "lettuce",
            "cabbage", "spinach", "kale", "collard greens", "broccoli", "cauliflower", "brussels sprouts",
            "bok choy", "swiss chard", "mustard greens", "turnip greens", "beet greens", "radicchio", "endive",
            "frisée", "escarole", "dandelion greens", "arugula", "mizuna", "watercress", "herbs", "basil",
            "parsley", "cilantro", "mint", "dill", "tarragon", "oregano", "marjoram", "thyme", "rosemary",
            "sage", "chives", "garlic", "onion", "scallion", "leek", "shallot", "chive", "carrot", "radish","turnip",
            "beet", "parsnip", "rutabaga", "celeriac", "potato", "sweet potato", "yam", "butternut squash",
            "acorn squash", "pumpkin", "zucchini", "summer squash", "pattypan squash", "spaghetti squash", "cucumber",
            "green bean", "pea", "snow pea", "snap pea", "okra", "lima bean", "fava bean", "mung bean", "chickpea",
            "lentil", "peanut", "soybean", "edamame", "mung bean", "split pea", "pigeon pea", "coconut", "cashew",
            "pistachio", "almond", "pecan", "walnut", "hazelnut", "chestnut", "peanut", "macadamia", "brazil nut",
            "pine nut", "beechnut", "hickory nut", "pignoli nut", "sunflower seed", "pumpkin seed", "sesame seed",
            "flaxseed", "chia seed", "poppy seed", "hemp seed", "wheat", "rye", "barley",
            "dog", "cat", "bird", "horse", "pig", "cow", "sheep", "goat", "chicken", "duck", "frog", "turtle",
            "rabbit", "hamster", "mouse", "gerbil", "rat", "guinea pig", "ferret", "beaver", "otter", "skunk",
            "kangaroo", "monkey", "chimpanzee", "gorilla", "lizard", "snake", "toad", "crocodile", "alligator",
            "dolphin", "whale", "shark", "fish", "crab", "lobster", "shrimp", "octopus", "squid", "clam", "scallop",
            "oyster", "mussel", "starfish", "sponge", "jellyfish", "seagull", "penguin", "pelican", "albatross",
            "swan", "goose", "duck", "heron", "ostrich", "emu", "turkey", "peacock", "parakeet", "parrot",
            "flamingo", "pigeon", "dove", "woodpecker", "sparrow", "robin", "blue jay", "cardinal", "finch",
            "thrush", "wren", "goldfinch", "toucan", "buzzard", "eagle", "raven", "crow", "magpie", "dormouse",
            "lemur", "opossum", "panda", "koala", "sloth", "ant eater", "gopher", "marmot", "chipmunk", "nutria",
            "mink", "weasel", "badger", "wombat", "hippopotamus", "rhinoceros", "giraffe", "elephant", "zebra",
            "antelope", "camel", "llama", "alpaca", "vicuna", "gazelle", "deer", "elk", "moose", "caribou",
            "reindeer", "bison", "wild boar", "pig", "warthog", "hyena", "jackal", "coyote", "dingo", "wolf",
            "fox", "kite", "vulture", "condor", "eagle", "falcon", "hawkeye", "hornet", "wasp", "beetle", "ant",
            "bee", "termite", "mosquito", "fly", "butterfly", "moth", "caterpillar", "centipede", "millipede",
            "spider", "scorpion", "tick", "mite", "louse", "flea", "bedbug", "aphid", "cicada", "cricket",
            "locust", "grasshopper", "praying mantis", "termite", "mantis", "roach", "bee", "wasp", "hornet",
            "yellow jacket", "firefly", "lightning bug", "ladybug", "dragonfly", "damselfly", "admiral", "aurora",
            "battalion", "apple", "banana", "orange", "pear", "grape", "strawberry", "raspberry", "blueberry",
            "blackberry", "mango", "peach", "apricot", "plum", "cherry", "fig", "kiwi", "pineapple", "papaya",
            "guava", "cantaloupe", "honeydew", "watermelon", "melon", "lemon", "lime", "orange", "tangerine",
            "mandarin", "clementine", "pomegranate", "persimmon", "quince", "nectarine", "arugula", "lettuce",
            "cabbage", "spinach", "kale", "collard greens", "broccoli", "cauliflower", "brussels sprouts",
            "bok choy", "swiss chard", "mustard greens", "turnip greens", "beet greens", "radicchio", "endive",
            "frisée", "escarole", "dandelion greens", "arugula", "mizuna", "watercress", "herbs", "basil",
            "parsley", "cilantro", "mint", "dill", "tarragon", "oregano", "marjoram", "thyme", "rosemary",
            "sage", "chives", "garlic", "onion", "scallion", "leek", "shallot", "chive", "carrot", "radish","turnip",
            "beet", "parsnip", "rutabaga", "celeriac", "potato", "sweet potato", "yam", "butternut squash",
            "acorn squash", "pumpkin", "zucchini", "summer squash", "pattypan squash", "spaghetti squash", "cucumber",
            "green bean", "pea", "snow pea", "snap pea", "okra", "lima bean", "fava bean", "mung bean", "chickpea",
            "lentil", "peanut", "soybean", "edamame", "mung bean", "split pea", "pigeon pea", "coconut", "cashew",
            "pistachio", "almond", "pecan", "walnut", "hazelnut", "chestnut", "peanut", "macadamia", "brazil nut",
            "pine nut", "beechnut", "hickory nut", "pignoli nut", "sunflower seed", "pumpkin seed", "sesame seed",
            "flaxseed", "chia seed", "poppy seed", "hemp seed", "wheat", "rye", "barley",
            "dog", "cat", "bird", "horse", "pig", "cow", "sheep", "goat", "chicken", "duck", "frog", "turtle",
            "rabbit", "hamster", "mouse", "gerbil", "rat", "guinea pig", "ferret", "beaver", "otter", "skunk",
            "kangaroo", "monkey", "chimpanzee", "gorilla", "lizard", "snake", "toad", "crocodile", "alligator",
            "dolphin", "whale", "shark", "fish", "crab", "lobster", "shrimp", "octopus", "squid", "clam", "scallop",
            "oyster", "mussel", "starfish", "sponge", "jellyfish", "seagull", "penguin", "pelican", "albatross",
            "swan", "goose", "duck", "heron", "ostrich", "emu", "turkey", "peacock", "parakeet", "parrot",
            "flamingo", "pigeon", "dove", "woodpecker", "sparrow", "robin", "blue jay", "cardinal", "finch",
            "thrush", "wren", "goldfinch", "toucan", "buzzard", "eagle", "raven", "crow", "magpie", "dormouse",
            "lemur", "opossum", "panda", "koala", "sloth", "ant eater", "gopher", "marmot", "chipmunk", "nutria",
            "mink", "weasel", "badger", "wombat", "hippopotamus", "rhinoceros", "giraffe", "elephant", "zebra",
            "antelope", "camel", "llama", "alpaca", "vicuna", "gazelle", "deer", "elk", "moose", "caribou",
            "reindeer", "bison", "wild boar", "pig", "warthog", "hyena", "jackal", "coyote", "dingo", "wolf",
            "fox", "kite", "vulture", "condor", "eagle", "falcon", "hawkeye", "hornet", "wasp", "beetle", "ant",
            "bee", "termite", "mosquito", "fly", "butterfly", "moth", "caterpillar", "centipede", "millipede",
            "spider", "scorpion", "tick", "mite", "louse", "flea", "bedbug", "aphid", "cicada", "cricket",
            "locust", "grasshopper", "praying mantis", "termite", "mantis", "roach", "bee", "wasp", "hornet",
            "yellow jacket", "firefly", "lightning bug", "ladybug", "dragonfly", "damselfly", "admiral", "aurora",
            "battalion", "apple", "banana", "orange", "pear", "grape", "strawberry", "raspberry", "blueberry",
            "blackberry", "mango", "peach", "apricot", "plum", "cherry", "fig", "kiwi", "pineapple", "papaya",
            "guava", "cantaloupe", "honeydew", "watermelon", "melon", "lemon", "lime", "orange", "tangerine",
            "mandarin", "clementine", "pomegranate", "persimmon", "quince", "nectarine", "arugula", "lettuce",
            "cabbage", "spinach", "kale", "collard greens", "broccoli", "cauliflower", "brussels sprouts",
            "bok choy", "swiss chard", "mustard greens", "turnip greens", "beet greens", "radicchio", "endive",
            "frisée", "escarole", "dandelion greens", "arugula", "mizuna", "watercress", "herbs", "basil",
            "parsley", "cilantro", "mint", "dill", "tarragon", "oregano", "marjoram", "thyme", "rosemary",
            "sage", "chives", "garlic", "onion", "scallion", "leek", "shallot", "chive", "JOHN DOE", "radish","turnip",
            "beet", "parsnip", "rutabaga", "celeriac", "potato", "sweet potato", "yam", "butternut squash",
            "acorn squash", "pumpkin", "zucchini", "summer squash", "pattypan squash", "spaghetti squash", "cucumber",
            "green bean", "pea", "snow pea", "snap pea", "okra", "lima bean", "fava bean", "mung bean", "chickpea",
            "lentil", "peanut", "soybean", "edamame", "mung bean", "split pea", "pigeon pea", "coconut", "cashew",
            "pistachio", "almond", "pecan", "walnut", "hazelnut", "chestnut", "peanut", "macadamia", "brazil nut",
            "pine nut", "beechnut", "hickory nut", "pignoli nut", "sunflower seed", "pumpkin seed", "sesame seed",
            "fox", "kite", "vulture", "condor", "eagle", "falcon", "hawkeye", "hornet", "wasp", "beetle", "ant",
            "bee", "termite", "mosquito", "fly", "butterfly", "moth", "caterpillar", "centipede", "millipede",
            "spider", "scorpion", "tick", "mite", "louse", "flea", "bedbug", "aphid", "cicada", "cricket",
            "locust", "grasshopper", "praying mantis", "termite", "mantis", "roach", "bee", "wasp", "hornet",
            "yellow jacket", "firefly", "lightning bug", "ladybug", "dragonfly", "damselfly", "admiral", "aurora",
            "battalion", "apple", "banana", "orange", "pear", "grape", "strawberry", "raspberry", "blueberry",
            "blackberry", "mango", "peach", "apricot", "plum", "cherry", "fig", "kiwi", "pineapple", "papaya",
            "guava", "cantaloupe", "honeydew", "watermelon", "melon", "lemon", "lime", "orange", "tangerine",
            "mandarin", "clementine", "pomegranate", "persimmon", "quince", "nectarine", "arugula", "lettuce",
            "cabbage", "spinach", "kale", "collard greens", "broccoli", "cauliflower", "brussels sprouts",
            "bok choy", "swiss chard", "mustard greens", "turnip greens", "beet greens", "radicchio", "endive",
            "frisée", "escarole", "dandelion greens", "flaxseed", "chia seed", "poppy seed", "hemp seed",
            "wheat", "jane doe", "barley",
        };
        private const string Value = "jane doe";
        private const string CaseInsensitiveValue = "John Doe";

        [Benchmark]
        public int ArrayIndexOf()
        {
            int index = Array.IndexOf(_stringArray, Value);

            return index;
        }

        [Benchmark]
        public int ArrayFindIndex()
        {
            int index = Array.FindIndex(_stringArray, str => str ==  Value);

            return index;
        }

        public int ArrayCaseInsensitiveFindIndex()
        {
            int index = Array.FindIndex(_stringArray, str => str.Equals(CaseInsensitiveValue, StringComparison.OrdinalIgnoreCase));
            
            return index;
        }

        [Benchmark]
        public int ForLoop()
        {
            int index = -1;
            for (int i = 0; i < _stringArray.Length; i++)
            {
                if (_stringArray[i] == Value)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        [Benchmark]
        public int ForEachLoop()
        {
            int index = -1;
            int step = 0;
            foreach (var item in _stringArray)
            {
                if (item == Value)
                {
                    index = step;
                    break;
                }
                step++;
            }

            return index;
        }

        [Benchmark]
        public int ListIndexOf()
        {
            var stringList = _stringArray.ToList();
            int index = stringList.IndexOf(Value);

            return index;
        }

        [Benchmark]
        public int ListFindIndex()
        {
            var stringList = _stringArray.ToList();
            int index = stringList.FindIndex(str => str == Value);

            return index;
        }

        public int ListCaseInsensitiveFindIndex()
        {
            var stringList = _stringArray.ToList();
            int index = stringList.FindIndex(str => str.Equals(CaseInsensitiveValue, StringComparison.OrdinalIgnoreCase));

            return index;
        }
    }
}
