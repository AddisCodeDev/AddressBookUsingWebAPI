using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.API.DataModel
{

        public class ResponseStatus
        {
            /// <summary>
            /// Instantiates a Response Status with an Errors list
            /// of Count zero i.e. no errors
            /// </summary>
            public ResponseStatus()
            {
                Errors = new List<string>();
            }


            //
            // Summary:
            //     Holds the custom ErrorCode enum if provided in ValidationException otherwise
            //     will hold the name of the Exception type, e.g. typeof(Exception).Name A value
            //     of non-null means the service encountered an error while processing the request.
            public string ErrorCode { get; set; }
            /// <summary>
            /// Every Error Recorded its description is added as a string.
            /// Hence if this list's count is zero then it means there are no errors
            /// </summary>
            public List<String> Errors { get; set; }
            //
            // Summary:
            //     A human friendly error message
            public string Message { get; set; }
            //
            public string StackTrace { get; set; }
        }
    }

