namespace Entities.Constants
{
    public static class ApiRoutes
    {
        public const string Root = "api/visualization";
        public const string Version = "v1";
        public const string Base = Root;
        //public const string Base = Root + "/" + Version;

        public static class VirtualDevices
        {
            public const string GetAll = Base + "/virtualdevices";
            public const string Create = Base + "/virtualdevice";
            public const string Update = Base + "/virtualdevice";
            public const string Delete = Base + "/virtualDevice/{id}";
            public const string ConnectionStatus = Base + "/connectionstatus/{deviceId}";
        }

        public static class Params
        {
            public const string GetAll = Base + "/params";
            public const string GetPerDevice = Base + "/params/{deviceId}";
            public const string GetAvailableReadParams = Base + "/availableReadParams/{deviceId}";
            public const string GetAvailableWriteParams = Base + "/availableWriteParams/{deviceId}";
            public const string Create = Base + "/param";
            public const string Update = Base + "/param";
            public const string Delete = Base + "/param/{paramId}";
        }

        public static class Ports
        {
            public const string GetAll = Base + "/ports";
            public const string Create = Base + "/port";
            public const string Update = Base + "/port/{id}";
            public const string Delete = Base + "/port/{id}";
            public const string DevicesWithSpecificPort = Base + "/portinuse/{portId}";
            public const string AssignPortToDevice = Base + "/porttodevice";
            public const string AssignProtocolToPort = Base + "/protocoltoport";
            public const string StopPort = Base + "/stopport/{virtualDeviceId}";
            public const string StartPort = Base + "/startport/{virtualDeviceId}";
            public const string AvailableSerialPorts = Base + "/availableports";
        }

        public static class Commands
        {
            public const string CreateModbusCommand = Base + "/modbusCommand";
            public const string UpdateModbusCommand = Base + "/modbuscommand";
            public const string CreateOvModbusCommand = Base + "/ovmodbusCommand";
            public const string UpdateOvModbusCommand = Base + "/ovmodbuscommand";
            public const string CreatePfeifferTc110Command = Base + "/pfeiffertc110command";
            public const string UpdatePfeifferTc110Command = Base + "/pfeiffertc110command";
            public const string CreatePfeifferTc400Command = Base + "/pfeiffertc400command";
            public const string UpdatePfeifferTc400Command = Base + "/pfeiffertc400command";
            public const string CreateXgs600Command = Base + "/xgs600command";
            public const string UpdateXgs600Command = Base + "/xgs600command";

            public const string GetModbusFunctions = Base + "/modbusfunctions";
            public const string GetCommandsPerDevice = Base + "/commands/{deviceId}";
            public const string GetCommandsPerParam = Base + "/commands";
            public const string Delete = Base + "/command/{commandId}";

            public const string TriggerCommand = Base + "/triggercommand";
            public const string TriggerCommandById = Base + "/triggercommand/{commandId}";

        }

        public static class Boards
        {
            public const string GetAll = Base + "/boards";
            public const string LoadBoard = Base + "/board/{boardId}";
            public const string GetBoardsByName = Base + "/board";
            public const string Save = Base + "/board";
            public const string Delete = Base + "/board/{boardId}";
        }

    }
}
