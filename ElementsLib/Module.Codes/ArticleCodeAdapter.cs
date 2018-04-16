﻿using System;
    using System.Collections.Generic;
    using System.Linq;

namespace ElementsLib.Module.Codes
{
    using ConfigCodeEnum = ArticleCodeCz;
    using EnumCode = UInt16;
    using ConfigRoleEnum = ArticleRoleCz;
    using EnumRole = UInt16;

    using BodyType = UInt16;
    using BodyItem = Interfaces.Elements.IArticleConfig;
    using BodyPair = KeyValuePair<UInt16, Interfaces.Elements.IArticleConfig>;

    using Libs;
    using Matrixus.Config;

    public class ArticleCodeAdapter
    {
        public static ConfigCodeEnum GetContractEnum()
        {
            return ConfigCodeEnum.ARTCODE_CONTRACT_TERM;
        }
        public static ConfigCodeEnum GetPositionEnum()
        {
            return ConfigCodeEnum.ARTCODE_POSITION_TERM;
        }
        public static ConfigCodeEnum GetDefaultsEnum()
        {
            return ConfigCodeEnum.ARTCODE_UNKNOWN;
        }
        public static EnumCode GetContractCode()
        {
            return (EnumCode)ConfigCodeEnum.ARTCODE_CONTRACT_TERM;
        }
        public static EnumCode GetPositionCode()
        {
            return (EnumCode)ConfigCodeEnum.ARTCODE_POSITION_TERM;
        }
        public static EnumCode GetDefaultsCode()
        {
            return (EnumCode)ConfigCodeEnum.ARTCODE_UNKNOWN;
        }
        public static ConfigCodeEnum CreateEnum(EnumCode symbolNumb)
        {
            return symbolNumb.ToEnum<ConfigCodeEnum>(GetDefaultsEnum());
        }
        public static ConfigCodeEnum CreateEnum(string symbolName)
        {
            return symbolName.ToEnum<ConfigCodeEnum>(GetDefaultsEnum());
        }
        public static EnumCode CreateCode(EnumCode symbolNumb)
        {
            return (EnumCode)symbolNumb.ToEnum<ConfigCodeEnum>(GetDefaultsEnum());
        }
        public static EnumCode CreateCode(string symbolName)
        {
            return (EnumCode)symbolName.ToEnum<ConfigCodeEnum>(GetDefaultsEnum());
        }
        public static IEnumerable<EnumCode> GetSelectedCodes()
        {
            IEnumerable<ConfigCodeEnum> symbolList = EnumUtilsExtensions.GetSelectedItems<ConfigCodeEnum>().ToList();

            IEnumerable<EnumCode> configList = symbolList.Select((c) => ((EnumCode)c)).ToList();

            return configList;
        }

        public static IEnumerable<EnumCode> GetAllCodes()
        {
            IEnumerable<ConfigCodeEnum> symbolList = EnumUtilsExtensions.GetAllItems<ConfigCodeEnum>().ToList();

            IEnumerable<EnumCode> configList = symbolList.Select((c) => ((EnumCode)c)).ToList();

            return configList;
        }

        public static IEnumerable<BodyPair> GetConfigurationList()
        {
            IList<BodyPair> configList = new List<BodyPair>();

            return configList;
        }
        public static string GetSymbol(EnumCode symbolNumb)
        {
            ConfigCodeEnum symbol = CreateEnum(symbolNumb);

            return symbol.GetSymbol();
        }

    }
}
