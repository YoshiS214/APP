import feedparser
import sys


Title = []
Desc = []
Link = []
txt = ""

if __name__ == '__main__':
    if len(sys.argv) == 3:
        d = feedparser.parse('https://'+ sys.argv[2] +'.news.yahoo.com/rss')

        for entry in d['entries']:
            try:
                Title.append(entry['title'])
            except:
                Title.append('No title')

            try:
                Link.append(entry['link'])
            except:
                Link.append('No link')
    
            try:
                Desc.append(entry['summary'])
            except:
                Title = Title[:-1]
                Link = Link[:-1]


        for a in range(int(sys.argv[1])):
            print (Title[a].replace("&#39;","'").replace("&quot;","'"))

            desc = Desc[a][Desc[a].index("</a>")+4:]
            desc = desc[:desc.index('<p>')]
            print (desc.replace("&#39;","'").replace("&quot;","'"))

            print ( Link[a]+"##new##")
            
    else:
        print ("Argument Error")
