using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
	public static class CellPatterns
	{
		public static string GLIDER =
@"-X-
--X\
XXX";
		public static string ROW = "XXXXXXXX-XXXXX---XXX------XXXXXXX-XXXXX";
		public static string SPACESHIP =
@"--XX-
-XXXX
XX-XX
-XX--";
		public static string GUN =
@"-------------------------X----------
----------------------XXXX----X-----
-------------X-------XXXX-----X-----
------------X-X------X--X---------XX
-----------X---XX----XXXX---------XX
XX---------X---XX-----XXXX----------
XX---------X---XX--------X----------
------------X-X---------------------
-------------X----------------------";
		public static string PULSAR =
	@"--XXX---XXX--
-------------
X----X-X----X
X----X-X----X
X----X-X----X
--XXX---XXX--
-------------
--XXX---XXX--
X----X-X----X
X----X-X----X
X----X-X----X
-------------
--XXX---XXX--";

	}
}
