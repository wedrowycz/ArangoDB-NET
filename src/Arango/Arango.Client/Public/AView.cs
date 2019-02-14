using System.Collections.Generic;
using Arango.Client.Protocol;
using Arango.fastJSON;

namespace Arango.Client
{
    public class AView
    {
        readonly Dictionary<string, object> _parameters = new Dictionary<string, object>();
        readonly Connection _connection;

        internal AView(Connection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Determines type of the collection. Default value: Document.
        /// </summary>
        public AView Type(AViewType value)
        {
            // set enum format explicitely to override global setting 
            _parameters.Enum(ParameterName.Type, value, EnumFormat.String);

            return this;
        }

        #region Create view (POST)

        /// <summary>
        /// Creates new collection in current database context.
        /// </summary>
        public AResult<Dictionary<string, object>> Create(string viewName)
        {
            var request = new Request(HttpMethod.POST, ApiBaseUri.View, "");
            var bodyDocument = new Dictionary<string, object>();
            bodyDocument.String(ParameterName.Name, viewName);
            // optional
            Request.TrySetBodyParameter(ParameterName.Type, _parameters, bodyDocument);
            request.Body = JSON.ToJSON(bodyDocument, ASettings.JsonParameters);

            var response = _connection.Send(request);
            var result = new AResult<Dictionary<string, object>>(response);

            switch (response.StatusCode)
            {
                case 201:
                    var body = response.ParseBody<Dictionary<string, object>>();

                    result.Success = (body != null);
                    result.Value = body;
                    break;
                default:
                    // Arango error
                    break;
            }

            _parameters.Clear();

            return result;
        }

        #endregion

        #region GetView

        /// <summary>
        /// Retrieves basic information with additional properties about specified view.
        /// </summary>
        public AResult<Dictionary<string, object>> GetProperties(string viewName)
        {
            var request = new Request(HttpMethod.GET, ApiBaseUri.View, "/" + viewName + "/properties");

            var response = _connection.Send(request);
            var result = new AResult<Dictionary<string, object>>(response);

            switch (response.StatusCode)
            {
                case 200:
                case 201:
                    var body = response.ParseBody<Dictionary<string, object>>();

                    result.Success = (body != null);
                    result.Value = body;
                    break;
                case 400:
                case 404:
                default:
                    // Arango error
                    break;
            }

            _parameters.Clear();

            return result;
        }
        #endregion


    }
}
