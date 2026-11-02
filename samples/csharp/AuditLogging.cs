// Selected excerpt from Services/AuditService.cs
// Illustrates audit-event persistence through the injected EF Core context.
// Enclosing types and application dependencies are intentionally omitted.

public async Task LogAsync(string eventType, string? actor = null, string? entityName = null, string? entityKey = null, string? message = null)
        {
            _db.AuditLogs.Add(new AuditLog
            {
                EventType = eventType,
                Actor = actor,
                EntityName = entityName,
                EntityKey = entityKey,
                Message = message,
                CreatedAt = DateTime.UtcNow
            });

            await _db.SaveChangesAsync();
        }
