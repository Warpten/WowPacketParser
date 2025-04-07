using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;

namespace WowPacketParser.Generators.Actions
{
    internal class DiagnosticProductionAction : IProductionAction
    {
        private DiagnosticProductionAction(DiagnosticDescriptor diagnostic, Location location, params object[]? args)
            => Diagnostic = Diagnostic.Create(diagnostic, location, args);

        private readonly Diagnostic Diagnostic;

        public void Run(SourceProductionContext context) => context.ReportDiagnostic(Diagnostic);

        public static IProductionAction Create(DiagnosticDescriptor descriptor, Location location, params object[]? args)
            => new DiagnosticProductionAction(descriptor, location, args);

        public static IProductionAction Create(DiagnosticDescriptor descriptor, IEnumerable<Location> locations, params object[]? args)
            => new AggregateProductionAction(locations.Select(loc => new DiagnosticProductionAction(descriptor, loc, args)));

        public static IProductionAction Create(DiagnosticDescriptor descriptor, IEnumerable<(Location Loc, object[] Args)> locations)
            => new AggregateProductionAction(locations.Select(loc => new DiagnosticProductionAction(descriptor, loc.Loc, loc.Args)));
    }
}
