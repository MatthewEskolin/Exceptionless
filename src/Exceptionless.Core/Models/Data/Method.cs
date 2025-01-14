﻿using Exceptionless.Core.Extensions;

namespace Exceptionless.Core.Models.Data;

public class Method : IData {
    public Method() {
        Data = new DataDictionary();
        GenericArguments = new GenericArguments();
        Parameters = new ParameterCollection();
    }

    public bool IsSignatureTarget { get; set; }
    public string DeclaringNamespace { get; set; }
    public string DeclaringType { get; set; }

    public string Name { get; set; }

    public int ModuleId { get; set; }
    public DataDictionary Data { get; set; }
    public GenericArguments GenericArguments { get; set; }
    public ParameterCollection Parameters { get; set; }

    protected bool Equals(Method other) {
        return IsSignatureTarget == other.IsSignatureTarget && String.Equals(DeclaringNamespace, other.DeclaringNamespace) && String.Equals(DeclaringType, other.DeclaringType) && String.Equals(Name, other.Name) && Equals(Data, other.Data) && GenericArguments.CollectionEquals(other.GenericArguments) && Parameters.CollectionEquals(other.Parameters);
    }

    public override bool Equals(object obj) {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != GetType())
            return false;

        return Equals((Method)obj);
    }

    public override int GetHashCode() {
        unchecked {
            int hashCode = IsSignatureTarget.GetHashCode();
            hashCode = (hashCode * 397) ^ (DeclaringNamespace?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ (DeclaringType?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ (Name?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ (Data?.GetCollectionHashCode(new[] { "ILOffset", "NativeOffset" }) ?? 0);
            hashCode = (hashCode * 397) ^ (GenericArguments?.GetCollectionHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ (Parameters?.GetCollectionHashCode() ?? 0);
            return hashCode;
        }
    }
}
