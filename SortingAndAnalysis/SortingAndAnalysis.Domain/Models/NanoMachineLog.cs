// NanoMachineLog.cs

using System;

namespace SortingAndAnalysis.Domain.Models;

/// <summary>
/// Лог наномашины — Value Object.
/// Описывает запись о выполненной задаче.
/// </summary>
public class NanoMachineLog
{
    public Guid Id { get; private set; }
    public string Data { get; private set; }
    public DateTime Timestamp { get; private set; }

    protected NanoMachineLog() { }

    public NanoMachineLog(string data)
    {
        Id = Guid.NewGuid();
        Data = data;
        Timestamp = DateTime.UtcNow;
    }
}